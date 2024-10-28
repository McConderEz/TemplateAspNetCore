using Template.Domain.Ids;
using Template.SharedKernel.Shared;

namespace Template.Domain.Entities
{
    public class Book: Entity<BookId>
    {
        private Book(BookId id) : base(id)
        {
        }

        public string Title { get; set; }            
        public string Author { get; set; }           
        public string ISBN { get; set; }             
        public DateTime PublicationDate { get; set; } 
        public string Genre { get; set; }            
        public int PageCount { get; set; }           
        public bool IsAvailable { get; set; }        
        public string Publisher { get; set; }       

        public Result TakeBook()
        {
            IsAvailable = false;

            return Result.Success();
        }

    }
}
