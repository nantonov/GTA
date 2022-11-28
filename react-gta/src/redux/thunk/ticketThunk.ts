import { AnyAction, ThunkDispatch } from "@reduxjs/toolkit";
import { ICreateUpdateTicketModel } from "../../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketModel";
import { createTicketService, deleteTicketService, getAllTicketsService, updateTicketService } from "../../services/TicketService";
import rootReducer from "../../store/reducers";
import { setTicketFail, setTicketStart, setTicketSuccess } from "../actionCreators/ticketAction";



export const getAllTickets = () => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setTicketStart());
    const tickets = await getAllTicketsService();
    dispatch(setTicketSuccess(tickets));
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setTicketFail(errorMessage));
}
};

export const postTicket = (ticket : ICreateUpdateTicketModel) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setTicketStart());
    const result = await createTicketService(ticket);
    if (result) {
        const tickets = await getAllTicketsService();
        dispatch(setTicketSuccess(tickets));
    }
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setTicketFail(errorMessage));
}
};

export const deleteTicket = (id : number) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setTicketStart());
    const result = await deleteTicketService(id);
    if (result) {
        const tickets = await getAllTicketsService();
        dispatch(setTicketSuccess(tickets));
    }
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setTicketFail(errorMessage));
}
};

export const updateTicket = (id: number, ticket: ICreateUpdateTicketModel) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
try {
    dispatch(setTicketStart());
    const result = await updateTicketService(id, ticket);
    if (result) {
        const tickets = await getAllTicketsService();
        dispatch(setTicketSuccess(tickets));
    }
} catch (error) {
    const errorMessage = (error as Error).message;
    dispatch(setTicketFail(errorMessage));
}
};