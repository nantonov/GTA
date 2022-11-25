import UserService from "../services/UserService";

export enum AuthActionTypes {
    SetIsAuth
}

export interface AuthAction {
    type: AuthActionTypes;
    isAuth: boolean;
    payload?: any;
}

export function setIsAuth(isAuth : boolean): AuthAction {
    return {
        type: AuthActionTypes.SetIsAuth,
        isAuth: isAuth
    };
}

type User = Awaited<ReturnType<typeof UserService.getUser>>;