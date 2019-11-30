﻿using Books.Api.ExternalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Services
{
    public interface IBooksRepository
    {
        IEnumerable<Entities.Book> GetBooks();

        //Entities.Book GetBook(Guid id);

        Task<IEnumerable<Entities.Book>> GetBooksAsync();

        Task<IEnumerable<Entities.Book>> GetBooksAsync(IEnumerable<Guid> bookIds);

        Task<Entities.Book> GetBookAsync(Guid id);

        Task<BookCover> GetBookCoverAsync(string coverId);


        void AddBook(Entities.Book bookToAdd);

        Task<bool> SaveChangesAsync();

    }
}
