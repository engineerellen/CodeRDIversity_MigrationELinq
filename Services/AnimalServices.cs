using Domain;
using Microsoft.Data.SqlClient;
using Repository;

namespace Services
{
    public class AnimalServices
    {
		AnimalContext _context;

        public AnimalServices(AnimalContext context)=>
            _context = context;

        public Animal ObterAnimal(Animal animal)
        {
            try
            {
                return _context.Animais.First(a => a.ID == animal.ID ||
                                               a.Nome == animal.Nome ||
                                               a.Raça == animal.Raça);
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Animal> ObterAnimais()
        {
            try
            {
                return _context.Animais.ToList();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InserirAnimal(Animal animal)
        {
			try
			{
				_context.Add(animal);
				_context.SaveChanges();
			}
			catch(SqlException)
			{
				throw;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public void AtualizarAnimal(Animal animal)
        {
            try
            {
                _context.Update(animal);
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoverAnimal(int ID)
        {
            try
            {
                Animal animal = new(){ ID = ID};

                _context.Remove(animal);
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}