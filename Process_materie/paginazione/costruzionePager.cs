﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Process_materie.paginazione
{

    public static class costruzionePager
    {

        public static void primaCostruzionePager(
            string viewTheme // it's just the prefix for the name; the whole name is this prefix after decoration on time-seed.
            , string ViewWhereTail
            , int rowXchunk
            , out int rowCardinalityTotalView
            , out string viewName // the actual whole name in the db. Useful for db-administrators.
            , out int rowInf
            , out int rowSup
            , out int par_lastPage
            , out System.Data.DataTable chunkDataSource
            , out Entity_materie.BusinessEntities.PagingCalculator par_pagingCalculator
            , out Entity_materie.BusinessEntities.Cacher cacherInstance
         )
        {
            //------start example use of Cacher-PagingCalculator-Pager--------------------------
            Entity_materie.BusinessEntities.ViewDynamics.accessPoint(viewTheme);// view theme. NB. decorate it!
            string designedViewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            cacherInstance = new Entity_materie.BusinessEntities.Cacher(
                new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder(
                    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                )
                , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(designedViewName)
                , ViewWhereTail // whereTail
            );
            rowCardinalityTotalView = cacherInstance.get_rowCardinalityTotalView();// out param
            viewName = cacherInstance.get_viewName();// out param
            //
            par_pagingCalculator = new Entity_materie.BusinessEntities.PagingCalculator(
                1 // #chunk : onConstruction the Default is goTo FirstChunk.
                , rowXchunk // row x chunk
                , rowCardinalityTotalView
            );
            //
            par_pagingCalculator.getRowInfSup(out rowInf, out rowSup, out par_lastPage);
            chunkDataSource = cacherInstance.getChunk(
                1 // first row
                , rowXchunk // last row: in the first chunk lastRow==rowXchunk
            );
        }// primaCostruzionePager


    }// class
}// nmsp
