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
    public class ContactGroupService : IContactGroupService
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

        public async Task<BatchGetContactGroupsResponse> BatchGet(string resourceNames, int maxMembers)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts, PeopleServiceService.Scope.ContactsReadonly });

            var list = service.ContactGroups.BatchGet();
            list.MaxMembers = maxMembers;
            list.ResourceNames = resourceNames;
            var response = await list.ExecuteAsync();
            return response;
        }

        public async Task<ContactGroup> ContactGroupsCreate(ContactGroup group)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });

            var body = new CreateContactGroupRequest();
            body.ContactGroup = group;
            var request = service.ContactGroups.Create(body);
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task ContactGroupsDelete(string resourceName,bool deleteContacts)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });

            var request = service.ContactGroups.Delete(resourceName);
            await request.ExecuteAsync();
        }

        public async Task<ContactGroup> ContactGroupsGet(string resourceName,int maxMembers)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts, PeopleServiceService.Scope.ContactsReadonly });

            var request = service.ContactGroups.Get(resourceName);
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task<ListContactGroupsResponse> ContactGroupsList(string pageToken,int pageSize,string syncToken)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts, PeopleServiceService.Scope.ContactsReadonly });

            var request = service.ContactGroups.List();
            request.PageToken = pageToken;
            request.PageSize = pageSize;
            request.SyncToken = syncToken;
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task<ContactGroup> ContactGroupsUpdate(string resourceName,ContactGroup group)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });

            var body = new UpdateContactGroupRequest();
            body.ContactGroup = group;
            var request = service.ContactGroups.Update(body, resourceName);
            var response = await request.ExecuteAsync();
            return response;
        }

        public async Task<ModifyContactGroupMembersResponse> ContactGroupsMembersModify(string resourceName, IList<string> resourceNamesToAdd, IList<string> resourceNamesToRemove)
        {
            await AuthenticateAsync(new[] { PeopleServiceService.Scope.Contacts });

            var body = new ModifyContactGroupMembersRequest();
            body.ResourceNamesToAdd = resourceNamesToAdd;
            body.ResourceNamesToRemove = resourceNamesToRemove;
            var request = service.ContactGroups.Members.Modify(body, resourceName);
            var response = await request.ExecuteAsync();
            return response;
        }
    }
}
