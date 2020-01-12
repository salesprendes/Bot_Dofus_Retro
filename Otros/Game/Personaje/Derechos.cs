namespace Bot_Dofus_Retro.Otros.Game.Personaje
{
	public class Derechos
    {
		public bool PUEDE_AGREDIR { get; private set; }
		public bool PUEDE_DESAFIAR { get; private set; }
		public bool PUEDE_INTERCAMBIAR { get; private set; }
		public bool PUEDE_ATACAR { get; private set; }
		public bool PUEDE_UTILIZAR_CHAT { get; private set; }
		public bool PUEDE_SER_MERCANTE { get; private set; }
		public bool PUEDE_UTILIZAR_OBJETOS { get; private set; }
		public bool PUEDE_INTERACTUAR_CON_RECAUDADORES { get; private set; }
		public bool PUEDE_UTILIZAR_OBJETOS_INTERACTIVOS { get; private set; }
		public bool PUEDE_DIALOGAR_NPC { get; private set; }
		public bool PUEDE_ATACAR_MOBS_EN_DUNG_SIENDO_MUTANTE { get; private set; }
		public bool PUEDE_MOVERSE_TODAS_DIRECCIONES { get; private set; }
		public bool PUEDE_ATACAR_MONSTRUOS_CUALQUIER_LUGAR_SIENDO_MUTANTE { get; private set; }
		public bool PUEDE_INTERACTUAR_PRISMA { get; private set; }

		public Derechos(int derecho) => set_Derechos(derecho);

		public void set_Derechos(int derecho)
		{
			PUEDE_AGREDIR = (derecho & 1) != 1;
			PUEDE_DESAFIAR = (derecho & 2) != 2;
			PUEDE_INTERCAMBIAR = (derecho & 4) != 4;
			PUEDE_ATACAR = (derecho & 8) == 8;
			PUEDE_UTILIZAR_CHAT = (derecho & 16) != 16;
			PUEDE_SER_MERCANTE = (derecho & 32) != 32;
			PUEDE_UTILIZAR_OBJETOS = (derecho & 64) != 64;
			PUEDE_INTERACTUAR_CON_RECAUDADORES = (derecho & 128) != 128;
			PUEDE_UTILIZAR_OBJETOS_INTERACTIVOS = (derecho & 256) != 256;
			PUEDE_DIALOGAR_NPC = (derecho & 512) == 512;
			PUEDE_ATACAR_MOBS_EN_DUNG_SIENDO_MUTANTE = (derecho & 4096) == 4096;
			PUEDE_MOVERSE_TODAS_DIRECCIONES = (derecho & 8192) == 8192;
			PUEDE_ATACAR_MONSTRUOS_CUALQUIER_LUGAR_SIENDO_MUTANTE = (derecho & 16384) == 16384;
			PUEDE_INTERACTUAR_PRISMA = (derecho & 32768) != 32768;
		}
	}
}
