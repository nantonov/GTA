import PagesTicketInput from "../../components/pages/inputs/PagesTicketInput";
import PagesTicketTable from "../../components/pages/tables/PagesTicketTable";

const Tickets = () => {
  return (
    <div>
      <PagesTicketInput creatingInput={true} id={0} />

      <PagesTicketTable />
    </div>
  );
};

export default Tickets;
