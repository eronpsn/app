using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eclilar.Dominio.Entidades;
using Eclilar.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Eclilar.Infraestrutura.BancoDados.Repositorios
{
    public class ProfissionalRepositorio: IProfissionalRepositorio {

        private readonly ContextoBanco _contextoBanco;

        public ProfissionalRepositorio(ContextoBanco contextoBanco) {
            _contextoBanco = contextoBanco;
        }

        public async  Task<IEnumerable<ProfissionalModel>> BuscaTodos() {
           
            return  await _contextoBanco.TProfissional.
                Where(p => p.ProfessionalAdminStatus == 1).
                OrderBy(a => a.ProfessionalName).
                ToListAsync();
            
            
        }

        public async  Task<IEnumerable<Categoria>> BuscaCategoria(int specialtyId) {
           
            return await _contextoBanco.TCategoria.
                Where(c => c.CategoryStatus == 1).
                Where(c => c.SpecialtyId == specialtyId).
                OrderBy(c => c.CategoryName).
                ToListAsync();
            
             
        }
        public async Task<IEnumerable<ProfissionalModel>> ProcuraProfissional(string specialtyId)
        {
            string sql = string.Format(@"SELECT p.professional_id,p.professional_name, p.professional_email, p.professional_phone, s.specialty_name AS professional_description,
                                        p.professional_image, p.rating, p.completed_attendance, p.professional_value_visit,p.professional_experience, p.professional_formation,
                                         p.city_id, p.professional_admin_status, '' as professional_password, p.professional_signup_date, p.register_date 
                                        FROM professional p INNER JOIN professional_specialty ps ON(p.professional_id = ps.id_professional_id) 
                                        INNER JOIN specialty s ON(s.specialty_id = ps.id_specialty_id) 
                                        WHERE s.specialty_id = {0} ", specialtyId);
            return await _contextoBanco.TProfissional.FromSqlRaw(sql).
                    OrderBy(a => a.ProfessionalName).
                    ToListAsync();
        }

    }
}
