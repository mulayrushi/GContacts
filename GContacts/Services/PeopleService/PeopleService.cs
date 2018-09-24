using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GContacts.Services
{
    public class PeopleService : IPeopleService
    {
        private UserCredential credential;
        private PeopleServiceService service;

        private async Task AuthenticateAsync(IEnumerable<string> scopes)
        {
            if (service != null)
                return;

            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new Uri("ms-appx:///Assets/client_secrets.json"),
                scopes,
                "user",
                CancellationToken.None);

            var initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "BloggerApp",
            };

            service = new PeopleServiceService(initializer);
        }

        public async Task<Person> PeopleCreateContact(Person person)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });
            
            var request = service.People.CreateContact(person);
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task PeopleDeleteContact(string resourceName)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });

            var request = service.People.DeleteContact(resourceName);
            var response = await request.ExecuteAsync();
        }

        public async Task<Person> PeopleGet(string resourceName,List<string> FieldMask )
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts, PeopleServiceService.Scope.ContactsReadonly, PeopleServiceService.Scope.PlusLogin, PeopleServiceService.Scope.UserAddressesRead, PeopleServiceService.Scope.UserBirthdayRead, PeopleServiceService.Scope.UserEmailsRead, PeopleServiceService.Scope.UserPhonenumbersRead, PeopleServiceService.Scope.UserinfoEmail, PeopleServiceService.Scope.UserinfoProfile });

            var request = service.People.Get(resourceName);
            request.PersonFields = FieldMask;
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task<GetPeopleResponse> PeopleGetBatchGet(List<string> resourceNames, List<string> FieldMask)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts, PeopleServiceService.Scope.ContactsReadonly, PeopleServiceService.Scope.PlusLogin, PeopleServiceService.Scope.UserAddressesRead, PeopleServiceService.Scope.UserBirthdayRead, PeopleServiceService.Scope.UserEmailsRead, PeopleServiceService.Scope.UserPhonenumbersRead, PeopleServiceService.Scope.UserinfoEmail, PeopleServiceService.Scope.UserinfoProfile });

            var request = service.People.GetBatchGet();
            request.ResourceNames = resourceNames;
            request.PersonFields = FieldMask;
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task PeopleUpdateContact(string resourceName, List<string> updatePersonFields)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });
            var person = new Person();

            var request = service.People.UpdateContact(person, resourceName);
        }

        public async Task PeopleConnectionsList(string resourceName, string pageToken, int pageSize, PeopleResource.ConnectionsResource.ListRequest.SortOrderEnum sortOrder, bool requestSyncToken, string syncToken, List<string> personFields)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts, PeopleServiceService.Scope.ContactsReadonly });

            var request = service.People.Connections.List(resourceName);
            request.PageToken = pageToken;
            request.PageSize = pageSize;
            request.SortOrder = sortOrder;
            request.RequestSyncToken = requestSyncToken;
            request.SyncToken = syncToken;
            request.PersonFields = personFields;

            var response = await request.ExecuteAsync();
        }
    }
}
