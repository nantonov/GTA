import React from "react";
import PagesCityInput from "../../components/pages/inputs/PagesCityInput";
import PagesCityTable from "../../components/pages/tables/PagesCityTable";

const Cities = () => {
  return (
    <div>
      <PagesCityInput creatingInput={true} id={0} />

      <PagesCityTable />
    </div>
  );
};

export default Cities;
