using KairosScheduler.Siiau.Helpers;

namespace Playground;

public class Playground
{
    public void Program()
    {
        var urlBuilder = new UrlBuilder();
        var url = urlBuilder.SetBaseUrl(@"http://consulta.siiau.udg.mx/wco/sspseca.consulta_oferta")
            .AddParameter("ciclop", SomeCiclo)
    
    
    
    }

}

//var url =  +
//                    $"ciclop={ciclo}&" + //Ciclo escolar
//                    $"cup={cu}&" + //Centro Universitario
//                    $"majrp={carrera}&" + // Clave de la carrera
//                    $"crsep={materiaClave}&" + //clave de materia
//                    $"materiap={materiaNombre}&" + //Nombre de materia
//                    "horaip=&" + //inicio horario
//                    "horafp=&" + //fin horario
//                    "edifp=&" + //edificio
//                    "aulap=&" +  //aula
//                    "ordenp=0&" + // Tipo de orden
//                    "mostrarp=6000"; //Cantidad Maxima