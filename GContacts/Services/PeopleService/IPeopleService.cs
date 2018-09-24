using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;

namespace GContacts.Services
{
    public interface IPeopleService
    {
        Task PeopleConnectionsList(string resourceName, string pageToken, int pageSize, PeopleResource.ConnectionsResource.ListRequest.SortOrderEnum sortOrder, bool requestSyncToken, string syncToken, List<string> personFields);
        Task<Person> PeopleCreateContact(Person person);
        Task PeopleDeleteContact(string resourceName);
        Task<Person> PeopleGet(string resourceName, List<string> FieldMask);
        Task<GetPeopleResponse> PeopleGetBatchGet(List<string> resourceNames, List<string> FieldMask);
        Task PeopleUpdateContact(string resourceName, List<string> updatePersonFields);
    }
}