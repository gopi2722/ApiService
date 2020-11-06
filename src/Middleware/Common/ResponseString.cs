using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public enum ResponseString
    {
        OK = 0,
        UnexpectedError = 1,
        DBError = 2,
        InvalidRequestData = 4,
        SeatsUnavailable = 8,
        FailedSeatDataRetrieve = 9,
        FailedOrderValueProcess = 10,
        PrepareOrderForCompleteError = 11,
        PaymentDeclined = 12,
        PaymentSystemError = 13,
        PostChargeCommitError = 14,
        PaymentSuccessWithErrors = 24,
        PaymentVoidSuccessPostCommit = 25,
        PaymentVoidSuccessPreCommit = 26,
        PaymentVoidSuccessPayTotalMismatch = 27,
        FailedToAllocateCard = 28,
        CouldNotAllocateContiguousSeats = 31,
        OrderInitFailed = 36,
        CardWalletAccessTokenInvalid = 37,
        RefundBookingFailed = 39,
        ExternalPaymentsDisabled = 45,
        BookingAlreadyCancelled = 49,
        SessionUnavailable = 50,
        TicketsNotOnSale = 51,
        PaymentsProcessed = 56,
        PaymentErrorPreCommit = 57,
        OrderCannotBeUniquelyIdentified = 61,
        OrderDoesNotExist = 62,
        OrderHasBeenRefunded = 63,
        TicketPriceOverrideDisallowed = 64,
        BookingFeeOverrideDisallowed = 65,
        CompleteOrderWithoutPerformingPaymentDisallowed = 66,
        SeatMapRequestedForSoldOutSession = 67,
        TicketTypeNotFound = 68,
        PaymentValueNotEqualOrderTotal = 69,
        BookingFeeOverrideMustBeProvided = 70,
        ConnectApiTokenNotSpecified = 71,
        ConnectApiTokenInvalid = 72,
        SiteNotFound = 73,
        BookingNotFound = 78,
        ConnectApiTokenForbidden = 79,
        BookingPaymentDataMismatch = 80,
        PaymentDoesNotExist = 81,
        WebPaymentModuleConnectionFailed = 82,
        OrderIsAlreadyBeingCompleted = 83,
        TicketBookingFeeOverrideDisallowed = 84,
        SelectedSeatsInvalidForTickets = 87,
        DeviceTokenMissing = 88,
        PhoneNumberMissing = 89,
        PaymentNotStarted = 90,
        OrderLockedForAsynchronousCompletion = 92,
        ExternalCardWalletUnavailable = 98

    }
}
