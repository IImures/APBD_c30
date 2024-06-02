using KolokwiumPrep.Group.Repository;

namespace KolokwiumPrep.Group.Service;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    
    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public Task<GroupEntity.GroupEntity?> GetGroupById(int id)
    {
        return _groupRepository.GetGroupById(id) ;
    }
}