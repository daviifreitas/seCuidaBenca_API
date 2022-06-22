using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tester01.Models;

[Table("ocorrencia")]
public class Ocorrencia
{
    [Column("id_ocorrencia")]
    [Key]
	public int Id_Ocorrencia { get; set; }
	public int Id_DoUsuario { get; set; }
	public string DescricaoDaOcorrencia { get; set; }

}
