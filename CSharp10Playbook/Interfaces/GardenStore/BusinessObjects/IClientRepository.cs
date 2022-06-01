﻿namespace BusinessObjects;

public interface IClientRepository
{
    GardenClient GetClientFromId(int clientId);

    bool PersistCart(GardenClient client);
}