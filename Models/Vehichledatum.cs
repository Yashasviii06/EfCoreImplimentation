using System;
using System.Collections.Generic;
using EfCoreImplimentation.Models;
using Microsoft.AspNetCore.Http.HttpResults;

using Microsoft.EntityFrameworkCore;

namespace EfCoreImplimentation.Models;

public partial class Vehichledatum
{
    public int VehId { get; set; }

    public int VehSerialno { get; set; }

    public string? VehName { get; set; }

    public int VehPrice { get; set; }
}


public static class VehichledatumEndpoints
{
	public static void MapVehichledatumEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Vehichledatum").WithTags(nameof(Vehichledatum));

        group.MapGet("/", async (DbfirstapproachContext db) =>
        {
            return await db.Vehichledata.ToListAsync();
        })
        .WithName("GetAllVehichledata");



        group.MapGet("/{id}", async Task<Results<Ok<Vehichledatum>, NotFound>> (int vehid, DbfirstapproachContext db) =>
        {
            return await db.Vehichledata.AsNoTracking()
                .FirstOrDefaultAsync(model => model.VehId == vehid)
                is Vehichledatum model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetVehichledatumById");



        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int vehid, Vehichledatum vehichledatum, DbfirstapproachContext db) =>
        {
            var affected = await db.Vehichledata
                .Where(model => model.VehId == vehid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.VehId, vehichledatum.VehId)
                  .SetProperty(m => m.VehSerialno, vehichledatum.VehSerialno)
                  .SetProperty(m => m.VehName, vehichledatum.VehName)
                  .SetProperty(m => m.VehPrice, vehichledatum.VehPrice)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateVehichledatum");


        group.MapPost("/", async (Vehichledatum vehichledatum, DbfirstapproachContext db) =>
        {
            db.Vehichledata.Add(vehichledatum);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Vehichledatum/{vehichledatum.VehId}", vehichledatum);
        })
        .WithName("CreateVehichledatum");


        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int vehid, DbfirstapproachContext db) =>
        {
            var affected = await db.Vehichledata
                .Where(model => model.VehId == vehid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteVehichledatum");
      
    }
}