using System;
using System.Collections.Generic;
using System.Collections;
using KS.Reactor.Server;
using KS.Reactor;

namespace Dakard.Game.Server
{
    public class GameServerRoom : ksServerRoomScript
    {
        // Called after all other scripts on all entities are attached.
        public override void Initialize()
        {
            Room.OnPlayerJoin += PlayerJoin;
            Room.OnPlayerLeave += PlayerLeave;
        }
        
        // Called when the script is detached.
        public override void Detached()
        {
            Room.OnPlayerJoin -= PlayerJoin;
            Room.OnPlayerLeave -= PlayerLeave;
        }
        
        // Called when a player connects.
        private void PlayerJoin(ksIServerPlayer player)
        {
            ksLog.Info("Player" + player.Id + " joined");
            ksIServerEntity playerEntity = Room.SpawnEntity("playerHand");
        }
        
        // Called when a player disconnects.
        private void PlayerLeave(ksIServerPlayer player)
        {
            ksLog.Info("Player" + player.Id + " left");
        }
    }
}