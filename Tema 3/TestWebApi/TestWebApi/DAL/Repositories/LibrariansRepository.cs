using System;
using System.Collections.Generic;
using System.Linq;
using Library.Lib.Models;
using Library.UI.DAL;

namespace Library.Lib.DAL
{
    public class LibrariansRepository : IDisposable
    {
        public LibraryDbContext DbContext { get; set; }

        public List<Librarian> LibrariansList
        {
            get
            {
                return GetAll();
            }
        }

        public LibrariansRepository()
        {
            DbContext = new LibraryDbContext();
            LoadInitData();
        }

        public void LoadInitData()
        {
            if (DbContext.Librarians.Count() == 0)
            {
                //creo Librarians de prueba
                var admin = new Librarian()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@library.com",
                    Surname1 = String.Empty,
                    Surname2 = String.Empty,
                    Password = "1234"
                };

                // y lo meto en el campo interno
                DbContext.Librarians.Add(admin);

                DbContext.SaveChanges();
            }

        }

        public List<Librarian> GetAll()
        {
            return DbContext.Librarians.ToList();
        }

        public Librarian Get(Guid id)
        {
            var output = DbContext.Librarians.Find(id);
            return output;
        }

        public List<Librarian> GetByName(string name)
        {

            var output = DbContext.Librarians.Where(s => s.Name == name).ToList();
            return output;
        }

        public LibrarianValidationsTypes Add(Librarian Librarian)
        {
            if (Librarian.Id != default(Guid))
            {
                // todo bien porque no hay ningún Id
                return LibrarianValidationsTypes.IdNotEmpty;
            }

            if (!Librarian.ValidateName(Librarian.Name))
            {
                return LibrarianValidationsTypes.WrongNameFormat;
            }
            //else if (!DbContext.Librarians.Any(s => s.Id == Librarian.Id)) ineficiente
            else if (DbContext.Librarians.All(s => s.Id != Librarian.Id)) // más eficiente
            {                
                Librarian.Id = Guid.NewGuid();
                DbContext.Librarians.Add(Librarian);
                DbContext.SaveChanges();

                return LibrarianValidationsTypes.Ok;
            }

            // si el Id no estaba vacío y ya existía en la DB devolvmenos false
            return LibrarianValidationsTypes.IdDuplicated;
        }

        public LibrarianValidationsTypes Update(Librarian Librarian)
        {
            if (Librarian.Id == default(Guid))
            {
                // no se puede actualizar un registro sin id
                return LibrarianValidationsTypes.IdEmpty;
            }
            if (DbContext.Librarians.All(s => s.Id != Librarian.Id))
            {
                // no se puede actualizar un registro
                // que no exista en la DB
                return LibrarianValidationsTypes.NotFound;
            }

            if (!Librarian.ValidateName(Librarian.Name))
            {
                return LibrarianValidationsTypes.WrongNameFormat;
            }

            DbContext.Librarians.Update(Librarian);
            DbContext.SaveChanges();

            return LibrarianValidationsTypes.Ok;
        }

        public LibrarianValidationsTypes Delete(Guid id)
        {
            var Librarian = DbContext.Librarians.Find(id);
            if (Librarian == null)
            {
                return LibrarianValidationsTypes.NotFound;
            }
            else
            {
                DbContext.Librarians.Remove(Librarian);
                return LibrarianValidationsTypes.Ok;
            }
        }

        public void Dispose()
        {
        }
    }
}
