namespace ProjetoEvolucional.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjetoEvolucional : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunoDisciplina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlunoId = c.Int(nullable: false),
                        DisciplinaId = c.Int(nullable: false),
                        Nota = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aluno", t => t.AlunoId)
                .ForeignKey("dbo.Disciplina", t => t.DisciplinaId)
                .Index(t => t.AlunoId)
                .Index(t => t.DisciplinaId);
            
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disciplina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlunoDisciplina", "DisciplinaId", "dbo.Disciplina");
            DropForeignKey("dbo.AlunoDisciplina", "AlunoId", "dbo.Aluno");
            DropIndex("dbo.AlunoDisciplina", new[] { "DisciplinaId" });
            DropIndex("dbo.AlunoDisciplina", new[] { "AlunoId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Disciplina");
            DropTable("dbo.Aluno");
            DropTable("dbo.AlunoDisciplina");
        }
    }
}
