import type { Schedule } from "@/models/schedule/Schedule"
import type { RequestResponse } from "../RequestResponse"

export type ScheduleResponse = RequestResponse<Schedule>
export type ScheduleListResponse = RequestResponse<Schedule[]>
