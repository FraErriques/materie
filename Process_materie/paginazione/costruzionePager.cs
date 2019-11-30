using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.paginazione
{

    public static class costruzionePager
    {

	/* Scopo di questa classe e' racchiudere le operazioni di istanziazione, inizializzazione e 
	 * soprattutto coordinamento dei tre oggetti Cacher, PagingCalculator ed Interface::Pager.
	 * Cacher e PagingCalculator appartengono ad Entity_materie. Interface::Pager deve essere
	 * implementato per ogni interfaccia e gestisce label, bottoni o linea di comando. Le istanze
	 * dei tre oggetti citati devono transitare come parametri di output, affinche' l'interfaccia
	 * chiamante possa passarle ad altri metodi di Process che dovono proseguire nel coordinamento
	 * della BusinessLogic. Il banco di test sara' di chiamare questo Process da Web::Pager e da 
	 * WinForms::Pager con risultati identici. La segnatura deve diventare:
	 * public static void primaCostruzionePager(
            string viewTheme
            ,out int rowCardinalityTotalView
	    ,out Entity_materie.BusinessEntities.Cacher instantiatedCacher
         )
	 */
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
