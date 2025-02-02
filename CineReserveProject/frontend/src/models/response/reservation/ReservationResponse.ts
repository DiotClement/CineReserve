import type { Reservation } from "@/models/reservation/Reservation"
import type { RequestResponse } from "../RequestResponse"

export type ReservationResponse = RequestResponse<Reservation>
export type ReservationListResponse = RequestResponse<Reservation[]>
