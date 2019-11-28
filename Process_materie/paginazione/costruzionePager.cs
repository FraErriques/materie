using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.paginazione
{

    public static class costruzionePager
    {

        public static void primaCostruzionePager(
            string viewTheme
            ,out int rowCardinalityTotalView
         )
        {
            //------start example use of Cacher-PagingCalculator-Pager--------------------------
            Entity_materie.BusinessEntities.ViewDynamics.accessPoint(viewTheme);// view theme. NB. decorate it!
            string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            Entity_materie.BusinessEntities.Cacher prototypeCacher = new Entity_materie.BusinessEntities.Cacher(
                new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                )
                , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(designedViewName)
                , "" // no whereTail
            );
            rowCardinalityTotalView = prototypeCacher.get_rowCardinalityTotalView();
            // call from outHere:
            // this.pager1.Init(prototypeCacher.get_rowCardinalityTotalView());// configure interface-Pager
            Entity_materie.BusinessEntities.PagingCalculator pagingCalc = new Entity_materie.BusinessEntities.PagingCalculator(
                1 // #chunk
                , 2 // row x chunk
                , rowCardinalityTotalView
            );

        }//


    }
}
