import PagesHotelInput from '../../components/pages/inputs/PagesHotelInput';
import PagesHotelTable from '../../components/pages/tables/PagesHotelTable';

const Hotels = () => {
    return (
        <div>
            <PagesHotelInput creatingInput={true} id={0}/>
            
            <PagesHotelTable/>
        </div>
    );
};

export default Hotels;