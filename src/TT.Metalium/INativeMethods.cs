namespace TT.Metalium
{
    public interface INativeMethods
    {
        // Creates a new device instance based on the given configuration.
        IDevice* CreateDevice(
            chip_id_t deviceId,
            byte numberOfHardwareCQs,
            ulong l1SmallSize,
            ulong traceRegionSize,
            DispatchCoreConfig dispatchCoreConfig,
            IEnumerable<uint> l1BankRemap,
            ulong workerL1Size);

        // Closes an existing device instance.
        void CloseDevice(IDevice* device);

        // Returns a collection of available device identifiers.
        IEnumerable<chip_id_t> QueryDevices();

        // Blocks until all previously dispatched commands on the given CommandQueue have completed.
        // Optionally, you can supply specific sub-device IDs to wait on.
        void Finish(ref CommandQueue cq, IEnumerable<SubDeviceId> subDeviceIds = null);

        // Begins capturing the Light Metal binary trace (for replay/tracing purposes).
        void LightMetalBeginCapture();

        // Ends the capture operation and returns the captured binary blob to the user.
        byte[] LightMetalEndCapture();
    }
}