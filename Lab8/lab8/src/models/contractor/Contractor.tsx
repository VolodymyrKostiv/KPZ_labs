import { GenderType } from "./GenderType"

export type Contractor = {
    id: number,
    firstName: string,
    lastName: string,
    age: number,
    gender: GenderType,
    contacts: string | null,
    techSkills: string | null,
    softSkills: string | null,
    experience: string | null,
    education: string | null
}
