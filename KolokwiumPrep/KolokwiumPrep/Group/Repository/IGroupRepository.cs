namespace KolokwiumPrep.Group.Repository;

public interface IGroupRepository
{
    Task<GroupEntity.GroupEntity> GetGroupById(int id);
}