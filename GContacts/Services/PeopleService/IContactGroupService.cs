using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.PeopleService.v1.Data;

namespace GContacts.Services
{
    public interface IContactGroupService
    {
        Task<BatchGetContactGroupsResponse> BatchGet(string resourceNames, int maxMembers);
        Task<ContactGroup> ContactGroupsCreate(ContactGroup group);
        Task ContactGroupsDelete(string resourceName, bool deleteContacts);
        Task<ContactGroup> ContactGroupsGet(string resourceName, int maxMembers);
        Task<ListContactGroupsResponse> ContactGroupsList(string pageToken, int pageSize, string syncToken);
        Task<ModifyContactGroupMembersResponse> ContactGroupsMembersModify(string resourceName, IList<string> resourceNamesToAdd, IList<string> resourceNamesToRemove);
        Task<ContactGroup> ContactGroupsUpdate(string resourceName, ContactGroup group);
    }
}