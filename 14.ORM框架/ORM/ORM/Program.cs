// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using ORM;

Console.WriteLine("Hello, World!");
BloggingContext context =new BloggingContext();
using (var tran = context.Database.BeginTransaction())
{
    // delete from tbl where id='1';
    context.DeleteRange<Equipment>(a => a.Id == "1");

    // update tbl set id =2 where id =1 
    context.BatchUpdate<Equipment>().Where(args => args.Id == "1")
        .Set(a => a.Id, "2")
        .Set(a => a.EquipmentName, "asd4")
        .Execute();
    
    context.EQUIPMENT.Add(new Equipment
    {
        EquipmentGroupId = "1",
        EquipmentName = "asd",
        Id = "1",
    });
    context.SaveChanges();

    var equipments = context.Set<Equipment>().AsNoTracking().Where(a => true).ToList();

    Console.WriteLine(equipments.Count);

    var equipment = context.Set<Equipment>().First();
    equipment.EquipmentName = "abc";

    context.SaveChanges();
    tran.Commit();
}
