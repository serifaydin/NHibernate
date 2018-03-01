using FluentNHibernate.Mapping;
using Panel.Models;

namespace Panel.NHibernateMapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("tblUser");
            Id(u => u.TabloID).GeneratedBy.Identity();
            Map(u => u.FirstName).Not.Nullable();
            Map(u => u.LastName).Not.Nullable();
            Map(u => u.Age).Not.Nullable();
            Map(u => u.RegisterDate);
        }
    }
}