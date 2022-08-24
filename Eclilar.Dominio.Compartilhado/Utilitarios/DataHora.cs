using System;

namespace Eclilar.Dominio.Compartilhado.Utilitarios
{
    public class DataHora
    {
      public static DateTime ObterDataHoraAtual() {
            return DateTime.UtcNow.AddHours(-3);
        }  
    }
}