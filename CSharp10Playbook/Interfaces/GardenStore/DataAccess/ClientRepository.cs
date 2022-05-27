﻿using BusinessObjects;

namespace DataAccess;

public class ClientRepository : IClientRepository 
{

    public GardenClient GetClientFromId(int clientId)
    {
		//we assume this is really getting the data from a database
        GardenClient client = new GardenClient(clientId, "Simon", this);
        return client;
    }
	public bool PersistCart(GardenClient client)
	{
		// we assume this will go to the database and log the purchases
		Console.WriteLine("Just for the demo, the cart is being persisted\r\n");
		return true;
	}

	public ClientRepository(string connectionString)
	{
		// we assume this will connect to the database
	}
}
