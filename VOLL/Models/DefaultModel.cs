using VOLL.BancoVOLL;

namespace VOLL.Models
{
    public class DefaultModel
    {
        static Table_1 ModelToEntity(DefaultViewModel d)
        {
            Table_1 t = null;
            if (d != null)
            {
                t = new Table_1();
                t.id = d.Id;
                t.description = d.Description;
            }
            return t;
        }
            
        public static void Include(DefaultViewModel d)
        {
            using (var context = new Model1())
            {
                var t = ModelToEntity(d);
                context.Entry(t).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
    }

    public class DefaultViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}