﻿using WHEDU_OA_DATAMODEL;


namespace WHEDU_OA_DAL
{
    public interface IDefineModelRepository
    {
         DefineModels GetDefineModelByID(string m_id);
        //DefineModels GetDefineModelByIDandVNO(string m_id, string vison_no);

        int AbateDefineModel(DefineModels model);

        int AddDefineModel(DefineModels dmodel);

        int AbateDefineModelByID(string m_id);

    }
}