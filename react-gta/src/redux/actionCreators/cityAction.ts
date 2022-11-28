import { CityActionTypes, CityAction } from "../actionTypes/cityTypes";
import { ICityGetModel } from "../../modelInterfaces/getInterfaces/ICityGetModel";

export const setCityStart = (): CityAction => ({
    type: CityActionTypes.CITY_START
})

export const setCitySuccess = (cities: ICityGetModel[]): CityAction => ({
    type: CityActionTypes.CITY_SUCCESS,
    payload: cities
})

export const setCityFail = (error: string): CityAction => ({
    type: CityActionTypes.CITY_FAIL,
    payload: error
})