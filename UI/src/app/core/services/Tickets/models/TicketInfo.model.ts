export interface TicketInfoModel {
  id: string;
  description: string;
  isActive: boolean;
  supportUserId: string;
  customerUserId: string;
  ticketContext: string;
  ticketContextResponse: string;
}
