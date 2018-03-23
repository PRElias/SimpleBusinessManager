using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimpleBusinessManager.Utils
{
    public static class CSVHelper
    {
        private const int WIN_1252_CP = 1252;
        private const string SEPARADOR_INICIAL = "sep=,";
        private const string ASPAS_SIMPLES = "\"";

        public static void GerarCSV<T>(string listaCabecalho, IEnumerable<T> listaConteudo, Stream stream, string separador = ",")
        {
            GerarCSV<T>(listaCabecalho.Split(char.Parse(separador)), listaConteudo, stream, separador);
        }

        public static void GerarCSV<T>(IEnumerable<string> listaCabecalho, IEnumerable<T> listaConteudo, Stream stream, string separador = ",")
        {
            using (StreamWriter sw = new StreamWriter(stream, Encoding.GetEncoding(WIN_1252_CP)))
            {
                FieldInfo[] fields = typeof(T).GetFields();
                PropertyInfo[] properties = typeof(T).GetProperties();

                sw.WriteLine(SEPARADOR_INICIAL);

                // cabecalho
                sw.WriteLine
                (
                    string.Join
                    (
                        separador,
                        listaCabecalho.Select
                        (
                            s => ASPAS_SIMPLES + s + ASPAS_SIMPLES
                        )
                    )
                );

                // conteudo
                foreach (var item in listaConteudo)
                {
                    sw.WriteLine
                    (
                        string.Join
                        (
                            separador,
                            fields.Select
                            (
                                f =>
                                    ASPAS_SIMPLES +
                                    (f.GetValue(item) == null ?
                                    string.Empty :
                                    SubstituirAspasSimplesPorDupla(f.GetValue(item))).ToString()
                                    + ASPAS_SIMPLES
                            )
                            .Concat
                            (
                                properties.Select
                                (
                                    p =>
                                        ASPAS_SIMPLES +
                                        (p.GetValue(item, null) == null ?
                                        string.Empty :
                                        SubstituirAspasSimplesPorDupla(p.GetValue(item, null))).ToString()
                                        + ASPAS_SIMPLES
                                ).ToArray()
                            )
                        )
                    );
                }
            }
        }

        private static object SubstituirAspasSimplesPorDupla(object obj)
        {
            var texto = obj.ToString();
            if (texto != null)
            {
                return texto.Replace(@"""", @"""""");
            }

            return texto;
        }
    }
}
