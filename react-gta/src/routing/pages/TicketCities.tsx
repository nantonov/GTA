import PagesTicketCityInput from "../../components/pages/inputs/PagesTicketCityInput";
import PagesTicketCityTable from "../../components/pages/tables/PagesTicketCityTable";

const TicketCities = () => {
  return (
    <div>
      <PagesTicketCityInput creatingInput={true} ticketId={0} cityId={0} />

      <PagesTicketCityTable />
    </div>
  );
};

export default TicketCities;
