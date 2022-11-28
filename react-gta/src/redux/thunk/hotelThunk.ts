import { AnyAction, ThunkDispatch } from "@reduxjs/toolkit";
import { ICreateUpdateHotelModel } from "../../modelInterfaces/createUpdateInterfaces/ICreateUpdateHotelModel";
import { createHotelService, deleteHotelService, getAllHotelsService, updateHotelService } from "../../services/HotelService";
import rootReducer from "../../store/reducers";
import { setHotelFail, setHotelStart, setHotelSuccess } from "../actionCreators/hotelAction";



export const getAllHotels = () => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setHotelStart());
    const hotels = await getAllHotelsService();
    dispatch(setHotelSuccess(hotels));
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setHotelFail(errorMessage));
}
};

export const postHotel = (hotel : ICreateUpdateHotelModel) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setHotelStart());
    const result = await createHotelService(hotel);
    if (result) {
        const hotels = await getAllHotelsService();
        dispatch(setHotelSuccess(hotels));
    }
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setHotelFail(errorMessage));
}
};

export const deleteHotel = (id : number) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setHotelStart());
    const result = await deleteHotelService(id);
    if (result) {
        const hotels = await getAllHotelsService();
        dispatch(setHotelSuccess(hotels));
    }
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setHotelFail(errorMessage));
}
};

export const updateHotel = (id: number, hotel: ICreateUpdateHotelModel) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setHotelStart());
    const result = await updateHotelService(id, hotel);
    if (result) {
        const hotels = await getAllHotelsService();
        dispatch(setHotelSuccess(hotels));
    }
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setHotelFail(errorMessage));
}
};