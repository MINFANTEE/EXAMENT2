using System.Collections.Generic;
using System.Linq;
using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;


namespace CalidadT2.Repositorio
{
    
    public interface IBibliotecaRepositorio
    {
        List<Biblioteca> Obt_Biblioteca(int id);
        Biblioteca Agr_Biblioteca(Biblioteca bibliote);
        Biblioteca Act_Estado(int libid, int useid);
        Biblioteca Mar_Terminado(int libroId, int id);
    }
    
    public class BibliotecaRepositorio: IBibliotecaRepositorio
    {
        private AppBibliotecaContext app;

        public BibliotecaRepositorio(AppBibliotecaContext app)
        {
            this.app = app;
        }

        public List<Biblioteca> Obt_Biblioteca(int id)
        {
          return app.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
        }

        public Biblioteca Agr_Biblioteca(Biblioteca bibliote)
        {
            app.Bibliotecas.Add(bibliote);
            app.SaveChanges();

            return bibliote;
        }

        public Biblioteca Act_Estado(int libd, int useid)
        {
            var libro = app.Bibliotecas.Where(o => o.LibroId == libd && o.UsuarioId == useid).FirstOrDefault();

            libro.Estado = ESTADO.LEYENDO;
            app.SaveChanges();

            return libro;
        }


        public Biblioteca Mar_Terminado(int libroId, int id)
        {
            var libro = app.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == id)
                .FirstOrDefault();

            libro.Estado = ESTADO.TERMINADO;
            app.SaveChanges();

            return libro;

        }

    }
}