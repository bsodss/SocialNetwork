import { Byte } from "@angular/compiler/src/util";

export class User {
    constructor(
        public id?: number,
        public firstName?: string,
        public lastName?: string,
        public city?: string,
        public isMale?: boolean,
        public MmainPhoto?: Array<Byte>,
        public userAccountFriendsIds?: string[],
        public friendRequestSentIds?: string[],
        public friendRequestReceivedIds?: string[],
        public postsIds?: string[]
    ) { }
}