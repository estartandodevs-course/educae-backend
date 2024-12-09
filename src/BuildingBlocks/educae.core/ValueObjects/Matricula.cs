namespace educae.core.ValueObjects
{
    public class Matricula
    {
        public string Numero { get; private set; }

        public Matricula(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Matrícula não pode ser vazia ou nula.");

            if (!EhValida(numero))
                throw new ArgumentException("Matrícula inválida.");

            Numero = numero.Trim();
        }

        public static bool EhValida(string matricula)
        {
            // Preciso checar se a matrícula será numérica ou alfanumérica
            return !string.IsNullOrWhiteSpace(matricula) &&
                   matricula.Length >= 5 &&
                   matricula.Length <= 15 &&
                   matricula.All(char.IsLetterOrDigit);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Matricula other) return false;

            return Numero == other.Numero;
        }

        public override int GetHashCode()
        {
            return Numero.GetHashCode();
        }

        public override string ToString()
        {
            return Numero;
        }
    }
}