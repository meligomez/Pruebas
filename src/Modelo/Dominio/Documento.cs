using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{

	public enum DocumentoTipoEnum { DNI = 0, LC = 1, LE = 2, Pasaporte = 3 };

	public class Documento
	{

		public static string[] string_docu = new string[4] { "DNI", "LC", "LE", "PASAPORTE" };
		private string tipoDocumento;
		private DocumentoTipoEnum tipo;
		private int numero;

		public int nroDoc
		{
			get { return numero; }
			set { numero = value; }
		}
		public string tipoDoc
		{
			get { return tipoDocumento; }
			set
			{
				tipoDocumento = value;
				tipo = enumByString(value);
			}
		}
		public DocumentoTipoEnum Tipo
		{
			get { return tipo; }
			set
			{
				tipo = value;
				tipoDocumento = stringByEnum(value);
			}
		}

		#region Constructores

		public Documento() { }

		public Documento(string tipoDocu, int num)
		{
			tipoDocumento = tipoDocu;
			numero = num;
		}

		#endregion

		private DocumentoTipoEnum enumByString(string cadena)
		{
			switch (cadena)
			{
				case "DNI":
					return DocumentoTipoEnum.DNI;
				case "LC":
					return DocumentoTipoEnum.LC;
				case "LE":
					return DocumentoTipoEnum.LE;
				case "Pasaporte":
					return DocumentoTipoEnum.Pasaporte;
			}
			return DocumentoTipoEnum.DNI;
		}

		private string stringByEnum(DocumentoTipoEnum enumerador)
		{
			switch (enumerador)
			{
				case DocumentoTipoEnum.DNI:
					return "DNI";
				case DocumentoTipoEnum.LC:
					return "LC";
				case DocumentoTipoEnum.LE:
					return "LE";
				case DocumentoTipoEnum.Pasaporte:
					return "Pasaporte";
			}
			return null;

		}


	}
}
