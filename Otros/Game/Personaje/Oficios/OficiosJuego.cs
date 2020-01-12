using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Oficios
{
    public class OficiosJuego : IDisposable, IEliminable
    {
        public List<Oficio> oficios { get; private set; }
        private bool oficios_iniciados;
        private bool disposed;
        public event Action oficios_actualizados;

        public OficiosJuego() => oficios = new List<Oficio>();
        public bool get_Tiene_Skill_Id(int id) => oficios.FirstOrDefault(j => j.skills.FirstOrDefault(s => s.id == id) != null) != null;
        public IEnumerable<short> get_Skills_Recoleccion_Disponibles() => oficios.SelectMany(oficio => oficio.skills.Where(skill => !skill.es_craft).Select(skill => skill.id));
        public IEnumerable<SkillsOficio> get_Skills_Disponibles() => oficios.SelectMany(oficio => oficio.skills.Select(skill => skill));

        public void get_Actualizar_Skills_Oficio(string paquete)
        {
            oficios_iniciados = false;

            string[] separador_skill;
            Oficio oficio;
            SkillsOficio skill = null;
            short id_oficio, id_skill;
            byte cantidad_minima, cantidad_maxima;
            float tiempo;

            foreach (string datos_oficio in paquete.Substring(3).Split('|'))
            {
                id_oficio = short.Parse(datos_oficio.Split(';')[0]);
                oficio = oficios.Find(x => x.id == id_oficio);

                if (oficio == null)
                {
                    oficio = new Oficio(id_oficio);
                    oficios.Add(oficio);
                }

                foreach (string datos_skill in datos_oficio.Split(';')[1].Split(','))
                {
                    separador_skill = datos_skill.Split('~');
                    id_skill = short.Parse(separador_skill[0]);
                    cantidad_minima = byte.Parse(separador_skill[1]);
                    cantidad_maxima = byte.Parse(separador_skill[2]);
                    tiempo = float.Parse(separador_skill[4]);
                    skill = oficio.skills.Find(actividad => actividad.id == id_skill);

                    if (skill != null)
                        skill.set_Actualizar(id_skill, cantidad_minima, cantidad_maxima, tiempo);
                    else
                        oficio.skills.Add(new SkillsOficio(id_skill, cantidad_minima, cantidad_maxima, tiempo));
                }
            }
            oficios_iniciados = true;
            oficios_actualizados?.Invoke();
        }

        public async Task get_Actualizar_Experiencia_oficio(string paquete)
        {
            while (!oficios_iniciados)
                await Task.Delay(50);

            string[] separador_oficio_experiencia = paquete.Substring(3).Split('|');
            uint experiencia_actual, experiencia_base, experiencia_siguiente_nivel;
            short id;
            byte nivel;

            foreach (string oficio in separador_oficio_experiencia)
            {
                id = short.Parse(oficio.Split(';')[0]);
                nivel = byte.Parse(oficio.Split(';')[1]);
                experiencia_base = uint.Parse(oficio.Split(';')[2]);
                experiencia_actual = uint.Parse(oficio.Split(';')[3]);

                if (nivel < 100)
                    experiencia_siguiente_nivel = uint.Parse(oficio.Split(';')[4]);
                else
                    experiencia_siguiente_nivel = 0;

                oficios.Find(x => x.id == id).set_Actualizar_Oficio(nivel, experiencia_base, experiencia_actual, experiencia_siguiente_nivel);
            }

            oficios_actualizados?.Invoke();
        }

        #region Zona Dispose
        public void limpiar() => oficios.Clear();
        public void Dispose() => Dispose(true);
        ~OficiosJuego() => Dispose(false);

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) { }

                oficios.Clear();
                oficios = null;
                disposed = true;
            }
        }
        #endregion
    }
}
