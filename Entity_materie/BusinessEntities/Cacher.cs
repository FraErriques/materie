using System;
 

namespace Entity_materie.BusinessEntities
{

    /// <summary>
    /// the Ctor calls a Proxy to build the appropriate View, via a functionPoiter( delegate).
    /// the Ctor calls a Proxy to get the View row-cardinality.
    /// the method getChunk( RowNumber inf, RowNumber sup) returns a dataTable with the required rows.
    /// No more rows travel on the telephon line; just the getChunk ones.
    /// </summary>
    public class Cacher
    {
        private string viewName;
        public delegate int SpecificViewBuilder(
                string where_tail,      // the specific join logic.
                string view_signature	// the View_name, generally the class Entity_materie.BusinessEntities.ViewDynamics
            );
        private SpecificViewBuilder specificViewBuilder = null;// can point to different viewCreation proxies.
        private int rowCardinalityTotalView;


        public Cacher(
            SpecificViewBuilder parSpecificViewBuilder
            , string parViewName
            , string whereTail
            )
        {
            if (null != parSpecificViewBuilder)
            {
                this.specificViewBuilder = parSpecificViewBuilder;// delegate
                if (
                    null == parViewName
                    || "" == parViewName.Trim()
                    )
                {
                    throw new System.Exception("CacherDbView::Ctor: illegal view name.");
                }// else can continue.
                this.viewName = parViewName;
                int viewCreation_res = this.specificViewBuilder(whereTail, this.viewName);
                System.Data.DataTable dtViewRowCardinality =
                    Entity_materie.Proxies.usp_ViewCacher_generic_LOAD_length_SERVICE.usp_ViewCacher_generic_LOAD_length(
                        this.viewName);
                if (
                    null == dtViewRowCardinality
                    || 0 >= dtViewRowCardinality.Rows.Count
                  )
                {
                    LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                        " exception :  CacherDbView Ctor failed querying the VIEW row-cardinality. check for View existence. "
                        , 0);
                }// else continue
                if (null != dtViewRowCardinality)
                {// TODO passare a func return val ?
                    this.rowCardinalityTotalView = (int)(dtViewRowCardinality.Rows[0].ItemArray[0]);
                }
            }// else : not a valid delegate -> do not Construct.
        }//Ctor



        public Cacher(
            SpecificViewBuilder parSpecificViewBuilder
            , string parViewName_uno
            , string parViewName_due
            ,bool isInDoubleSplit // when a temporary first view is required, to add RowNumber in a second turn.
            )
        {
            if (null != parSpecificViewBuilder)
            {
                this.specificViewBuilder = parSpecificViewBuilder;// delegate
                if (
                    null == parViewName_uno || "" == parViewName_uno.Trim()
                    || null == parViewName_due || "" == parViewName_due.Trim()
                  )
                {
                    throw new System.Exception("CacherDbView::Ctor: illegal view name(s).");
                }// else can continue.
                this.viewName = parViewName_due;// the first one is not cached.
                int viewCreation_res = this.specificViewBuilder(
                    parViewName_uno
                    , parViewName_due
                );
                System.Data.DataTable dtViewRowCardinality =
                    Entity_materie.Proxies.usp_ViewCacher_generic_LOAD_length_SERVICE.usp_ViewCacher_generic_LOAD_length(
                        this.viewName);
                if (
                    null == dtViewRowCardinality
                    || 0 >= dtViewRowCardinality.Rows.Count
                  )
                {
                    LoggingToolsContainerNamespace.LoggingToolsContainer.LogBothSinks_DbFs(
                        " exception :  CacherDbView Ctor failed querying the VIEW row-cardinality. check for View existence. "
                        , 0);
                }// else continue
                if (null != dtViewRowCardinality)
                {// TODO passare a func return val ?
                    this.rowCardinalityTotalView = (int)(dtViewRowCardinality.Rows[0].ItemArray[0]);
                }
            }// else : not a valid delegate -> do not Construct.
        }//Ctor


        public System.Data.DataTable getChunk(int parRowInf, int parRowSup)
        {
            System.Data.DataTable requiredChunk =
                Entity_materie.Proxies.usp_ViewGetChunk_SERVICE.usp_ViewGetChunk(
                    this.viewName
                    , parRowInf
                    , parRowSup
                );
            // ready.
            return requiredChunk;
        }// getChunk


        public int get_rowCardinalityTotalView()
        {
            return this.rowCardinalityTotalView;
        }// get_rowCardinalityTotalView


        public string get_viewName()
        {
            return this.viewName;
        }// get_viewName


    }// class


}// nmsp
