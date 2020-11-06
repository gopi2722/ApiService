using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{  
    public static class ResponseCodes
    {
        public const int Status0OK = 0;
        public const int Status1UnexpectedError = 1;
        public const int Status2DBError = 2;
        public const int Status4InvalidRequestData = 4;
        public const int Status8SeatsUnavailable = 8;
        public const int Status9FailedSeatDataRetrieve = 9;
        public const int Status10FailedOrderValueProcess = 10;
        public const int Status11PrepareOrderForCompleteError = 11;
        public const int Status12PaymentDeclined = 12;
        public const int Status13PaymentSystemError = 13;
        public const int Status14PostChargeCommitError = 14;
        public const int Status24PaymentSuccessWithErrors = 24;
        public const int Status25PaymentVoidSuccessPostCommit = 25;
        public const int Status26PaymentVoidSuccessPreCommit = 26;
        public const int Status27PaymentVoidSuccessPayTotalMismatch = 27;
        public const int Status28FailedToAllocateCard = 28;
        public const int Status31CouldNotAllocateContiguousSeats = 31;
        public const int Status36OrderInitFailed = 36;
        public const int Status37CardWalletAccessTokenInvalid = 37;
        public const int Status39RefundBookingFailed = 39;
        public const int Status45ExternalPaymentsDisabled = 45;
        public const int Status49BookingAlreadyCancelled = 49;
        public const int Status50SessionUnavailable = 50;
        public const int Status51TicketsNotOnSale = 51;
        public const int Status56PaymentsProcessed = 56;
        public const int Status57PaymentErrorPreCommit = 57;
        public const int Status61OrderCannotBeUniquelyIdentified = 61;
        public const int Status62OrderDoesNotExist = 62;
        public const int Status63OrderHasBeenRefunded = 63;
        public const int Status64TicketPriceOverrideDisallowed = 64;
        public const int Status65BookingFeeOverrideDisallowed = 65;
        public const int Status66CompleteOrderWithoutPerformingPaymentDisallowed = 66;
        public const int Status67SeatMapRequestedForSoldOutSession = 67;
        public const int Status68TicketTypeNotFound = 68;
        public const int Status69PaymentValueNotEqualOrderTotal = 69;
        public const int Status70BookingFeeOverrideMustBeProvided = 70;
        public const int Status71ConnectApiTokenNotSpecified = 71;
        public const int Status72ConnectApiTokenInvalid = 72;
        public const int Status73SiteNotFound = 73;
        public const int Status78BookingNotFound = 78;
        public const int Status79ConnectApiTokenForbidden = 79;
        public const int Status80BookingPaymentDataMismatch = 80;
        public const int Status81PaymentDoesNotExist = 81;
        public const int Status82WebPaymentModuleConnectionFailed = 82;
        public const int Status83OrderIsAlreadyBeingCompleted = 83;
        public const int Status84TicketBookingFeeOverrideDisallowed = 84;
        public const int Status87SelectedSeatsInvalidForTickets = 87;
        public const int Status88DeviceTokenMissing = 88;
        public const int Status89PhoneNumberMissing = 89;
        public const int Status90PaymentNotStarted = 90;
        public const int Status92OrderLockedForAsynchronousCompletion = 92;
        public const int Status98ExternalCardWalletUnavailable = 98;       

    }
}