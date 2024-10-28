using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.DomainEvents;
using Template.Domain.Entities;
using Template.Domain.Ids;
using Template.SharedKernel.Shared;

namespace Template.Domain.Aggregate
{
    public class Librarian: Entity<LibrarianId>
    {
        private Librarian(LibrarianId id): base(id) { }

        public string Name { get; set; }             
        public string Email { get; set; }         
        public string PhoneNumber { get; set; }  
        public DateTime HireDate { get; set; }    
        public string LibrarySection { get; set; } 
        public int YearsOfExperience { get; set; } 
        public bool IsFullTime { get; set; }
        public List<Book> Books { get; set; } = [];


        public Result TakeBook(Guid bookId)
        {
            //TODO: Проверка что эта книга в учёте этого библиотекаря

            AddDomainEvent(new BookTakenDomainEvent(Id.Id, bookId));

            return Result.Success();
        }
    }
}
