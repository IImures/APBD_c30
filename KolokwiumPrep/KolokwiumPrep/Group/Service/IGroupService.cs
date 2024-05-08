namespace KolokwiumPrep.Group.Service;

public interface IGroupService
{
    Task<GroupEntity.GroupEntity?> GetGroupById(int id);
}