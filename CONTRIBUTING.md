# Contributing

QZ Companion is an Android app that bridges NordicTrack/ProForm fitness devices to the [QZ](https://github.com/cagnulein/qdomyos-zwift) ecosystem. It controls speed and incline by injecting accessibility gestures directly on the iFit console.

## Quick Start

```bash
git clone <repo>
cd QZCompanionNordictrackTreadmill
./run-tests.sh          # run the unit test suite
```

Open the `app/` directory in Android Studio to build and sideload to a device.

## Adding a Device

The most common contribution is support for a new treadmill or bike model. Follow the step-by-step pattern in [CLAUDE.md](CLAUDE.md#new-device-implementation-pattern), then add tests following [testing-methodology.md](app/src/test/java/org/cagnulein/qzcompanionnordictracktreadmill/testing-methodology.md).

See [docs/architecture.md](docs/architecture.md) for a full picture of how the system fits together, and [docs/migrating-from-3x.md](docs/migrating-from-3x.md) for context on how the codebase evolved.

## Code Style

See [Code Style Guidelines](CLAUDE.md#code-style-guidelines) in CLAUDE.md. Key points:

- Comments only for non-obvious *why*, never *what*
- English only
- No multi-line comment blocks or docstrings

## Pull Requests

- One device (or one fix) per PR — keep scope narrow
- Tests are required for new devices
- Run `./run-tests.sh` before opening a PR

## Questions

Open a [GitHub Issue](../../issues) or start a [Discussion](../../discussions).
