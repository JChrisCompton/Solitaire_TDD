using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireLibrary
{
    public interface iMove
    {
        bool TakeFrom(Pile pile, int StartCardLoc);

        bool MoveTo(Pile sourcePile, Pile movePile);

        //bool Undo(Pile movePile);

        //bool Move(Pile sourcePile, int startCardLoc, Pile destPile);
    }
}
