using Bot_Dofus_Retro.Otros.Peleas.Enums;
using System.IO;

namespace Bot_Dofus_Retro.Otros.Game.Personaje.Configuracion
{
    public class PeleaHechizos
    {
        public short id { get; private set; } = 0;
        public string nombre { get; private set; } = null;
        public HechizoFocus focus { get; private set; }
        public byte lanzamientos_x_turno { get; private set; }
        public byte lanzamientos_restantes { get; set; }
        public byte turno_lanzado { get; set; }
        public byte vida_objetivo { get; private set; }
        public MetodoLanzamiento metodo_lanzamiento { get; private set; }
        public bool es_aoe { get; private set; }
        public bool necesita_piedra { get; private set; }
        public byte distancia_minima { get; private set; }

        public PeleaHechizos(short _id, string _nombre, HechizoFocus _focus, MetodoLanzamiento _metodo_lanzamiento, byte _lanzamientos_x_turno, byte _distancia_minima, bool _es_aoe, bool _necesita_piedra, byte _vida_objetivo)
        {
            id = _id;
            nombre = _nombre;
            focus = _focus;
            metodo_lanzamiento = _metodo_lanzamiento;
            lanzamientos_x_turno = _lanzamientos_x_turno;
            lanzamientos_restantes = lanzamientos_x_turno;
            distancia_minima = _distancia_minima;
            es_aoe = _es_aoe;
            necesita_piedra = _necesita_piedra;
            vida_objetivo = _vida_objetivo;
            turno_lanzado = 0;
        }

        public void guardar(BinaryWriter bw)
        {
            bw.Write(id);
            bw.Write(nombre);
            bw.Write((byte)focus);
            bw.Write((byte)metodo_lanzamiento);
            bw.Write(lanzamientos_x_turno);
            bw.Write(distancia_minima);
            bw.Write(es_aoe);
            bw.Write(necesita_piedra);
            bw.Write(vida_objetivo);
        }

        public static PeleaHechizos cargar(BinaryReader br) => new PeleaHechizos(br.ReadInt16(), br.ReadString(), (HechizoFocus)br.ReadByte(), (MetodoLanzamiento)br.ReadByte(), br.ReadByte(), br.ReadByte(), br.ReadBoolean(), br.ReadBoolean(), br.ReadByte());
    }
}
