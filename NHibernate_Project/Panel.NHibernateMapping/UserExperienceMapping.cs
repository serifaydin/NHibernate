using FluentNHibernate.Mapping;
using Panel.Models;

namespace Panel.NHibernateMapping
{
    public class UserExperienceMapping : ClassMap<UserExperience>
    {
        public UserExperienceMapping()
        {
            Table("tblUserExperience");
            Id(u => u.TabloID).GeneratedBy.Identity();
            Map(u => u.Description);
            Map(u => u.CountExperience).Not.Nullable();
            Map(u => u.UserID).Not.Nullable();
            Map(u => u.RegisterDate).Not.Nullable();
        }
    }
}