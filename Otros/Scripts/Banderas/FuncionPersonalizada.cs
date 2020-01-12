using MoonSharp.Interpreter;

namespace Bot_Dofus_Retro.Otros.Scripts.Banderas
{
    public class FuncionPersonalizada : Bandera
    {
        public DynValue funcion { get; private set; }

        public FuncionPersonalizada(DynValue _funcion) => funcion = _funcion;
    }
}
