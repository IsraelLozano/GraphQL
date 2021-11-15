using Dic.GraphQL.Demo.Contracts;
using Dic.GraphQL.Demo.Entities;
using Dic.GraphQL.Demo.Entities.Context;

namespace Dic.GraphQL.Demo.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }

        public IEnumerable<Owner> GetAll()=>_context.Owners.ToList();

        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(o => o.Id.Equals(id));

        public Owner UpdateOwner(Owner dbOwner, Owner owner)
        {
            dbOwner.Name = owner.Name;
            dbOwner.Address = owner.Address;
            _context.SaveChanges();
            return dbOwner;
        }
    }
}
