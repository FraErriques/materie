using System;
using System.Text;


namespace Entity_materie.BusinessEntities
{


    public class PagingManager
    {
        public string viewName;
        public int rowCardinalityTotalView;
        public Entity_materie.BusinessEntities.PagingCalculator pagingCalculator;
        public Entity_materie.BusinessEntities.Cacher cacherInstance;
        public System.Data.DataTable chunkDataSource;


        public PagingManager(
            string viewTheme // it's just the prefix for the name; the whole name is this prefix after decoration on time-seed.
            , string ViewWhereTail
            , Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder viewBuilderProxyFpointer
            , int rowXchunk
         )
        {
            //------start example use of Cacher-PagingCalculator-Pager--------------------------
            Entity_materie.BusinessEntities.ViewDynamics.accessPoint(viewTheme);// view theme. NB. decorate it!
            this.viewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            cacherInstance = new Entity_materie.BusinessEntities.Cacher(
                //new Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder( no more of this; which view to create, has to be
                // a choice of the caller. Not hard coded here.
                //    Entity_materie.Proxies.usp_ViewCacher_specific_CREATE_autore_SERVICE.usp_ViewCacher_specific_CREATE_autore
                //)
                 viewBuilderProxyFpointer
                , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator( this.viewName)
                , ViewWhereTail // whereTail
            );
            this.rowCardinalityTotalView = cacherInstance.get_rowCardinalityTotalView();
            this.pagingCalculator = new PagingCalculator(
                1 // first chunk required, onCtor()
                , rowXchunk
                , cacherInstance.get_rowCardinalityTotalView()
            );
            //
            this.pagingCalculator.getRowInfSup(
                out pagingCalculator.rowInf, 
                out pagingCalculator.rowSup, 
                out pagingCalculator.actual_lastPage );
            this.pagingCalculator.required_lastPage = this.pagingCalculator.actual_lastPage;// align.
            this.chunkDataSource = cacherInstance.getChunk(
                1 // first row
                , rowXchunk // last row: in the first chunk lastRow==rowXchunk
            );
        }// Ctor


        public PagingManager(
            string view_one
            // , string view_two DON'T ask for it. Here is the place of its creation.
            , Entity_materie.BusinessEntities.Cacher.SpecificViewBuilder viewBuilderProxyFpointer
            , int rowXchunk
            //-------
            , bool isInDoubleSplit
         )
        {//--------- isInDoubleSplit---------------------
            string view_two = "AutOnM_due_";// theme
            Entity_materie.BusinessEntities.ViewDynamics.accessPoint(view_two);// view theme. NB. decorate it!
            this.viewName = Entity_materie.BusinessEntities.ViewDynamics.Finalise.lastGeneratedView;// get the View name
            cacherInstance = new Entity_materie.BusinessEntities.Cacher(
                 viewBuilderProxyFpointer
                , view_one// this one already has [..]
                , Entity_materie.FormatConverters.ViewNameDecorator_SERVICE.ViewNameDecorator(this.viewName)
                , true // isInDoubleSplit
            );
            this.rowCardinalityTotalView = cacherInstance.get_rowCardinalityTotalView();
            this.pagingCalculator = new PagingCalculator(
                1 // first chunk required, onCtor()
                , rowXchunk
                , cacherInstance.get_rowCardinalityTotalView()
            );
            //
            this.pagingCalculator.getRowInfSup(
                out pagingCalculator.rowInf,
                out pagingCalculator.rowSup,
                out pagingCalculator.actual_lastPage);
            this.pagingCalculator.required_lastPage = this.pagingCalculator.actual_lastPage;// align.
            this.chunkDataSource = cacherInstance.getChunk(
                1 // first row
                , rowXchunk // last row: in the first chunk lastRow==rowXchunk
            );
        }// Ctor



    }// class


}// nmsp
